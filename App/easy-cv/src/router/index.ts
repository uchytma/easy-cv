import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/home/HomeView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/app",
      name: "app",
      component: () => import("../views/app/AppView.vue"),
    },
  ],
});

export default router;
