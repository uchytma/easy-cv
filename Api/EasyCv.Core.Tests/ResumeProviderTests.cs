using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain;
using EasyCv.Core.ResumeDomain.Exceptions;
using EasyCv.Core.ResumeDomain.Services;
using EasyCv.Core.Tests.DummyRepos;
using System;

namespace EasyCv.Core.Tests
{
    [TestClass]
    public class ResumeProviderTests
    {
        public ResumeProviderTests()
        {
            ResumeRepository = new ResumeRepositoryInMemory();
            SecurityKeyRepository = new ResumeSecurityKeyRepositoryInMemory();
            ResumeProvider = new ResumeProvider(ResumeRepository, SecurityKeyRepository);
        }

        private IResumeRepository ResumeRepository  { get; init; }
        private IResumeSecurityKeyRepository SecurityKeyRepository { get; init; }
        private ResumeProvider ResumeProvider { get; init; }


        [TestMethod]
        public async Task TestGetById()
        {
            //arrange
            Guid guid = new Guid("29321752-ca5c-4777-9a1b-ffcbec2a5d50");
            await ResumeRepository.Create(new Resume(guid, "test@test.cz", "{}"));

            //act
            var resp = await ResumeProvider.GetById(guid);

            //assert
            Assert.AreEqual(guid.ToString(), resp.Id.ToString());
            Assert.AreEqual("test@test.cz", resp.Email);
            Assert.AreEqual("{}", resp.JsonData);
        }

        [TestMethod]
        [ExpectedException(typeof(ResumeNotFoundException))]
        public async Task TestByIdNotFound()
        {
            //arrange
            Guid guid = new Guid("29321752-ca5c-4777-9a1b-ffcbec2a5d50");

            //act
            var _ = await ResumeProvider.GetById(guid);

            //assert by attribute
        }

        [TestMethod]
        public async Task TestCreate()
        {
            //arrange
            string email = "test@test.cz";
            string jsonData = "{}";
            Guid securityKey = new Guid("29321752-ca5c-4777-9a1b-ffcbec2a5d50");

            //act
            var resume = await ResumeProvider.Create(email, jsonData, securityKey);

            //assert
            var itemInRepo = await ResumeRepository.GetById(resume.Id);
            Assert.AreNotEqual(Guid.Empty, resume.Id);
            Assert.AreEqual(resume, itemInRepo);
            Assert.AreEqual(email, itemInRepo.Email);
            Assert.AreEqual(jsonData, itemInRepo.JsonData);

            var securityKeyInRepo = await SecurityKeyRepository.GetResumeSecurityKey(itemInRepo);
            Assert.AreEqual(securityKey, securityKeyInRepo);
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            //arrange
            Guid guid = new Guid("29321752-ca5c-4777-9a1b-ffcbec2a5d50");
            await ResumeRepository.Create(new Resume(guid, "test@test.cz", "{}"));
            string newEmail = "new@email.com";
            string newJsonData = "{ \"newJson\" : true}";

            //act
            await ResumeProvider.Update(new Resume(guid, newEmail, newJsonData));

            //assert
            var itemInRepo = await ResumeRepository.GetById(guid);
            Assert.AreEqual(guid, itemInRepo.Id);
            Assert.AreEqual(newEmail, itemInRepo.Email);
            Assert.AreEqual(newJsonData, itemInRepo.JsonData);
        }

        [TestMethod]
        public async Task TestCheckSecurityKeyIsValid()
        {
            //arrange
            Guid securityKey = new Guid("aa248c54-661d-4cf1-84b9-eb3f04e2102e");
            var resume = await ArrangeResumeWithSecurityKey(securityKey);

            //act
            var valid = await ResumeProvider.SecurityKeyIsValid(securityKey, resume);

            //assert
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public async Task TestCheckSecurityKeyIsInvalid()
        {
            //arrange
            Guid securityKey = new Guid("aa248c54-661d-4cf1-84b9-eb3f04e2102e");
            Guid securityKey2 = new Guid("e40f9e27-836b-478f-ace8-b67b18de6ed8");
            var resume = await ArrangeResumeWithSecurityKey(securityKey);

            //act
            var valid = await ResumeProvider.SecurityKeyIsValid(securityKey2, resume);

            //assert
            Assert.AreEqual(false, valid);
        }

        private async Task<Resume> ArrangeResumeWithSecurityKey(Guid securityKey)
        {
            Guid guid = new Guid("29321752-ca5c-4777-9a1b-ffcbec2a5d50");
            var resume = new Resume(guid, "test@test.cz", "{}");
            await ResumeRepository.Create(resume);
            await SecurityKeyRepository.SetResumeSecurityKey(resume, securityKey);
            return resume;
        }
    }
}