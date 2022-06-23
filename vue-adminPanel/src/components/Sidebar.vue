<template>
  <div class="flex">
    <!-- Backdrop -->
    <div
      :class="isOpen ? 'block' : 'hidden'"
      @click="isOpen = false"
      class="fixed inset-0 z-20 transition-opacity bg-black opacity-50 lg:hidden"
    ></div>
    <!-- End Backdrop -->

    <div
      :class="isOpen ? 'translate-x-0 ease-out' : '-translate-x-full ease-in'"
      class="fixed inset-y-0 left-0 z-30 w-64 overflow-y-auto transition duration-300 transform bg-gray-900 lg:translate-x-0 lg:static lg:inset-0"
    >
      <div class="flex items-center justify-center mt-8">
        <div class="flex items-center">
          <svg
            class="w-8 h-8 ml-2 text-blue-500"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M19.428 15.428a2 2 0 00-1.022-.547l-2.387-.477a6 6 0 00-3.86.517l-.318.158a6 6 0 01-3.86.517L6.05 15.21a2 2 0 00-1.806.547M8 4h8l-1 1v5.172a2 2 0 00.586 1.414l5 5c1.26 1.26.367 3.414-1.415 3.414H4.828c-1.782 0-2.674-2.154-1.414-3.414l5-5A2 2 0 009 10.172V5L8 4z"
            ></path>
          </svg>

          <span class="mx-2 text-2xl font-semibold text-white"
            >KOZMOS Admin</span
          >
        </div>
      </div>

      <nav class="mt-10">
        <!-- <p class="pl-4 text-xs font-semibold mb-4 text-gray-400">GENERAL</p> -->
        <router-link
          class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
          :class="[$route.name === 'Dashboard' ? activeClass : inactiveClass]"
          to="/dashboard"
        >
          <svg
            class="fill-blue-500"
            xmlns="http://www.w3.org/2000/svg"
            height="40"
            width="40"
          >
            <path
              d="M8.333 33.333V15.833L20.042 7.042L31.667 15.833V33.333H23.167V22.542H16.833V33.333Z"
            />
          </svg>

          <span class="mx-4">Ana Sayfa</span>
        </router-link>
        <!-- <p class="pl-4 my-2 text-xs font-semibold mb-4 text-gray-400">
          Examples
        </p> -->

        <router-link
          class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
          :class="[$route.name === 'Urunler' ? activeClass : inactiveClass]"
          to="/urunler"
        >
          <svg
            class="fill-blue-500"
            xmlns="http://www.w3.org/2000/svg"
            height="40"
            width="40"
          >
            <path
              d="M12.875 17.625H17.625V12.875H12.875ZM22.375 17.625H27.125V12.875H22.375ZM12.875 27.125H17.625V22.375H12.875ZM22.375 27.125H27.125V22.375H22.375ZM7.417 31.667Q6.417 31.667 5.708 30.958Q5 30.25 5 29.25V10.75Q5 9.75 5.708 9.042Q6.417 8.333 7.417 8.333H32.583Q33.583 8.333 34.292 9.042Q35 9.75 35 10.75V29.25Q35 30.25 34.292 30.958Q33.583 31.667 32.583 31.667Z"
            />
          </svg>

          <span class="mx-4">Ürünler</span>
        </router-link>

        <router-link
          class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
          :class="[$route.name === 'Tables' ? activeClass : inactiveClass]"
          to="/tables"
        >
          <svg
            class="fill-blue-500"
            xmlns="http://www.w3.org/2000/svg"
            height="40"
            width="40"
          >
            <path
              d="M20 35.25Q18.833 35.25 17.979 34.479Q17.125 33.708 17 32.542H23Q22.875 33.708 22.021 34.479Q21.167 35.25 20 35.25ZM14.125 29.333V27.917H25.875V29.333ZM14.167 24.708Q11.833 23.125 10.5 20.812Q9.167 18.5 9.167 15.625Q9.167 11.125 12.333 7.958Q15.5 4.792 20 4.792Q24.5 4.792 27.667 7.958Q30.833 11.125 30.833 15.625Q30.833 18.5 29.5 20.812Q28.167 23.125 25.833 24.708Z"
            />
          </svg>

          <span class="mx-4">Site Bilgileri</span>
        </router-link>

        <router-link
          class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
          :class="[$route.name === 'Kategoriler' ? activeClass : inactiveClass]"
          to="/kategoriler"
        >
          <svg
            class="fill-blue-500"
            xmlns="http://www.w3.org/2000/svg"
            height="40"
            width="40"
          >
            <path
              d="M13.167 16.958 20 5.75 26.875 16.958ZM29.25 35.375Q26.625 35.375 24.875 33.604Q23.125 31.833 23.125 29.25Q23.125 26.625 24.875 24.875Q26.625 23.125 29.25 23.125Q31.833 23.125 33.604 24.875Q35.375 26.625 35.375 29.25Q35.375 31.833 33.604 33.604Q31.833 35.375 29.25 35.375ZM6.292 34.458V23.917H16.833V34.458Z"
            />
          </svg>

          <span class="mx-4">Kategoriler</span>
        </router-link>

        <router-link
          class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
          :class="[$route.name === 'Cards' ? activeClass : inactiveClass]"
          to="/cards"
        >
          <svg
            class="fill-blue-500"
            xmlns="http://www.w3.org/2000/svg"
            height="40"
            width="40"
          >
            <path
              d="M14.208 27.583H15.625V25.833H17.792Q18.292 25.833 18.646 25.458Q19 25.083 19 24.583V20.542Q19 20 18.646 19.625Q18.292 19.25 17.792 19.25H12.208V15.583H19V14.167H15.625V12.417H14.208V14.167H12.083Q11.542 14.167 11.167 14.542Q10.792 14.917 10.792 15.458V19.458Q10.792 20 11.167 20.333Q11.542 20.667 12.083 20.667H17.583V24.417H10.792V25.833H14.208ZM26.792 26.625 29.083 24.333H24.5ZM24.5 16.083H29.083L26.792 13.792ZM7.417 31.667Q6.417 31.667 5.708 30.958Q5 30.25 5 29.25V10.75Q5 9.75 5.708 9.042Q6.417 8.333 7.417 8.333H32.583Q33.583 8.333 34.292 9.042Q35 9.75 35 10.75V29.25Q35 30.25 34.292 30.958Q33.583 31.667 32.583 31.667Z"
            />
          </svg>

          <span class="mx-4">İndirimler</span>
        </router-link>

        <router-link
          class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
          :class="[$route.name === 'Grafikler' ? activeClass : inactiveClass]"
          to="/grafikler"
        >
          <svg
            class="fill-blue-500"
            xmlns="http://www.w3.org/2000/svg"
            height="40"
            width="40"
          >
            <path
              d="M5.583 34.167V15.833H12.833V34.167ZM16.375 34.167V5.833H23.625V34.167ZM27.125 34.167V19.167H34.375V34.167Z"
            />
          </svg>

          <span class="mx-4">Grafikler</span>
        </router-link>

        <router-link
          class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
          :class="[
            $route.name === 'IletisimSayfasi' ? activeClass : inactiveClass,
          ]"
          to="/iletisimsayfasi"
        >
          <svg
            class="fill-blue-500"
            xmlns="http://www.w3.org/2000/svg"
            height="40"
            width="40"
          >
            <path
              d="M21.292 17.833V7.875Q21.292 7.375 21.688 7.042Q22.083 6.708 22.583 6.708H32Q32.5 6.708 32.875 7.042Q33.25 7.375 33.25 7.875V13.625Q33.25 14.167 32.896 14.542Q32.542 14.917 32 14.917H24.292ZM31.458 33.125Q27.208 33.125 22.812 30.875Q18.417 28.625 14.833 25.062Q11.25 21.5 9 17.104Q6.75 12.708 6.75 8.458Q6.75 7.708 7.25 7.188Q7.75 6.667 8.542 6.667H12.333Q13.083 6.667 13.583 7.083Q14.083 7.5 14.208 8.25L15.083 12.042Q15.208 12.667 15.062 13.208Q14.917 13.75 14.5 14.083L10.833 17.542Q13.208 21.5 16.104 24.375Q19 27.25 22.875 29.375L26.458 25.667Q26.875 25.208 27.375 25.042Q27.875 24.875 28.458 25L31.708 25.708Q32.417 25.833 32.833 26.354Q33.25 26.875 33.25 27.625V31.333Q33.25 32.125 32.75 32.625Q32.25 33.125 31.458 33.125Z"
            />
          </svg>
          <span class="mx-4">İletişim</span>
        </router-link>
      </nav>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { useSidebar } from "../hooks/useSidebar";

const { isOpen } = useSidebar();
const activeClass = ref(
  "bg-gray-600 bg-opacity-25 text-gray-100 border-gray-100"
);
const inactiveClass = ref(
  "border-gray-900 text-gray-500 hover:bg-gray-600 hover:bg-opacity-25 hover:text-gray-100"
);
</script>
