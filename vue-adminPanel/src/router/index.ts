import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Dashboard from "../views/Dashboard.vue";
import Kategoriler from "../views/Kategoriler.vue";
import Tables from "../views/Tables.vue";
import Urunler from "../views/Urunler.vue";
import Login from "../views/Login.vue";
import SiparisTakibi from "../views/SiparisTakibi.vue";
import Grafikler from "../views/Grafikler.vue";
import Card from "../views/CardView.vue";
import HesapIslemleri from "../views/HesapIslemleri.vue";
import IletisimSayfasi from "../views/IletisimSayfasi.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Login",
    component: Login,
    meta: { layout: "empty" },
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
  },
  {
    path: "/kategoriler",
    name: "Kategoriler",
    component: Kategoriler,
  },
  {
    path: "/cards",
    name: "Cards",
    component: Card,
  },
  {
    path: "/tables",
    name: "Tables",
    component: Tables,
  },
  {
    path: "/urunler",
    name: "Urunler",
    component: Urunler,
  },
  {
    path: "/siparistakibi",
    name: "SiparisTakibi",
    component: SiparisTakibi,
  },
  {
    path: "/grafikler",
    name: "Grafikler",
    component: Grafikler,
  },
  {
    path: "/hesapislemleri",
    name: "HesapIslemleri",
    component: HesapIslemleri,
  },
  {
    path: "/iletisimsayfasi",
    name: "IletisimSayfasi",
    component: IletisimSayfasi,
  },

  // { path: "/:pathMatch(.*)*", component: NotFound },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
