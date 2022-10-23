import { createApp } from "vue";
import { createPinia } from "pinia";

import App from "./App.vue";
import router from "./router";

import "./assets/main.css";

/** Font awesome */
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
  faPhoneSquare,
  faMailBulk,
  faMapMarked,
  faXmark,
  faTrashCan,
  faCircleChevronUp,
  faCircleChevronDown,
} from "@fortawesome/free-solid-svg-icons";
import { faLinkedin, faGithub } from "@fortawesome/free-brands-svg-icons";

library.add(
  faPhoneSquare,
  faMailBulk,
  faMapMarked,
  faLinkedin,
  faGithub,
  faXmark,
  faTrashCan,
  faCircleChevronUp,
  faCircleChevronDown
);

import { useMainAppStore } from "@/stores/mainApp";

const app = createApp(App);

app.component("font-awesome-icon", FontAwesomeIcon);

app.use(createPinia());
app.use(router);

app.mount("#app");

useMainAppStore().loadDefaultModel(); //called async - not waiting for result
