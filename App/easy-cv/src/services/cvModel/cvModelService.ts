import type {
  CvModel,
  CvModelSection,
  CvModelItemText,
  CvModelItemTextarea,
  CvModelItemPanel,
} from "@/services/cvModel/cvModel";

/**
 * Returns default cv model, with prefilled sections and items.
 */
export function getDefaultCv(): CvModel {
  const phone: CvModelItemText = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336caa",
    icon: "phone",
    text: {
      text: "+420 777 ??? ???",
      linkUrl: "tel:+420777??????",
      bold: false,
      muted: false,
    },
    subtext: null,
    type: "text",
  };

  const email: CvModelItemText = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336cbb",
    icon: "email",
    text: {
      text: "uchytma@gmail.com",
      linkUrl: "mailto:uchytma@gmail.com",
      bold: false,
      muted: false,
    },
    subtext: null,
    type: "text",
  };

  const linkedin: CvModelItemText = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336ccc",
    icon: "linkedin",
    text: {
      text: "linkedin.com/in/uchytma",
      linkUrl: "https://www.linkedin.com/in/uchytma",
      bold: false,
      muted: false,
    },
    subtext: null,
    type: "text",
  };

  const github: CvModelItemText = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336cdd",
    icon: "github",
    text: {
      text: "github.com/uchytma",
      linkUrl: "https://github.com/uchytma",
      bold: false,
      muted: false,
    },
    subtext: null,
    type: "text",
  };

  const address: CvModelItemText = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336cee",
    icon: "location",
    text: {
      text: "Praha - 9, Českomoravská",
      linkUrl: "https://www.google.com/maps/search/%C4%8Deskomoravsk%C3%A1/@50.1072772,14.4914009,16.6z",
      bold: false,
      muted: false,
    },
    subtext: null,
    type: "text",
  };

  const desc: CvModelItemTextarea = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336cff",
    text: {
      text: `Jsem FullStack vývojář, v současnosti s preferencí vývoje na platformě .NET. Zabývám se také analýzou a specifikací požadavků (tvorbu implementačních zadání na základě business požadavků), návrhem architektury a vhodných řešení.
             <br><br>
             Programování zůstává nadále mým hlavním zameřením a snažím se v něm neustále zdokonalovat. Obecně sleduji trendy v oblasti IT, a to nejen ve spojení s .NET a Microsoft technologiemi. Navštěvuji přednášky skupiny WUG či IT konference, jako například WUG Days či WeAreDevelopers World Congress.
             <br><br>
             Vlastním řidičský průkaz skupiny B.
             <br><br>
             Rád cestuji a díky dobře zvolenému oboru se snažím využívat možností práce na dálku ze zahraničí.`,
      linkUrl: null,
      bold: false,
      muted: false,
    },
    type: "textarea",
  };

  const mainSection: CvModelSection = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336c0c",
    header: {
      title: "Matěj Uchytil",
      subtitle: "nar. ?.?.????",
      size: "big",
    },
    items: [phone, email, linkedin, github, address, desc],
  };

  const eduCvut: CvModelItemPanel = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336aaa",
    type: "panel",
    title: {
      text: "ČVUT - Fakulta informačních technologí",
      linkUrl: null,
      bold: false,
      muted: false,
    },
    description: {
      text: "Softwarové inženýrství",
      linkUrl: "https://fit.cvut.cz/cs",
      bold: false,
      muted: false,
    },
    subtitle: {
      text: "2013 – 2015; studium nedokončeno. Hlavní město Praha, Česká republika",
      linkUrl: null,
      bold: false,
      muted: true,
    },
    imageUrl: "/imgs/cvut.png",
    rating: null,
    longText: null,
  };

  const eduSpse: CvModelItemPanel = {
    guid: "31e9c9c6-6926-4de5-b9b1-43779c336bbb",
    type: "panel",
    title: {
      text: "Střední průmyslová škola elektrotechnická",
      linkUrl: null,
      bold: false,
      muted: false,
    },
    description: {
      text: "Informační technologie",
      linkUrl: "https://www.uzlabina.cz/",
      bold: false,
      muted: false,
    },
    subtitle: {
      text: "2010 – 2013; V Úžlabině 320, Hlavní město Praha, Česká republika",
      linkUrl: null,
      bold: false,
      muted: true,
    },
    imageUrl: "/imgs/spse.svg",
    rating: null,
    longText: null,
  };

  const eduSection: CvModelSection = {
    guid: "aae9c9c6-6926-4de5-b9b1-43779c336c0c",
    header: {
      title: "Vzdělání",
      subtitle: null,
      size: "normal",
    },
    items: [eduCvut, eduSpse],
  };

  const cv: CvModel = { sections: [mainSection, eduSection] };

  return cv;
}
