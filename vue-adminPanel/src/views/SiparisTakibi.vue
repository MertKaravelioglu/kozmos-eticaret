<template>
  <div>
    <!-- Breadcrumb -->
    <!-- <Breadcrumb breadcrumb="Modal" /> -->
    <button
      @click="open = true"
      class="
        px-6
        py-2
        mt-3
        font-medium
        tracking-wide
        text-white
        bg-indigo-600
        rounded-md
        hover:bg-indigo-500
        focus:outline-none
      "
    >
      <svg
        class="w-6"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
      >
        <path
          fill-rule="evenodd"
          d="M6.707 4.879A3 3 0 018.828 4H15a3 3 0 013 3v6a3 3 0 01-3 3H8.828a3 3 0 01-2.12-.879l-4.415-4.414a1 1 0 010-1.414l4.414-4.414zm4 2.414a1 1 0 00-1.414 1.414L10.586 10l-1.293 1.293a1 1 0 101.414 1.414L12 11.414l1.293 1.293a1 1 0 001.414-1.414L13.414 10l1.293-1.293a1 1 0 00-1.414-1.414L12 8.586l-1.293-1.293z"
          clip-rule="evenodd"
        />
      </svg>
      Open Modal
    </button>

    <div
      :class="`modal ${
        !open && 'opacity-0 pointer-events-none'
      } z-50 fixed w-full h-full top-0 left-0 flex items-center justify-center`"
    >
      <div
        @click="open = false"
        class="absolute w-full h-full bg-gray-900 opacity-50 modal-overlay"
      ></div>

      <div
        class="
          z-50
          w-11/12
          mx-auto
          overflow-y-auto
          bg-white
          rounded
          shadow-lg
          modal-container
          md:max-w-md
        "
      >
        <div
          class="
            absolute
            top-0
            right-0
            z-50
            flex flex-col
            items-center
            mt-4
            mr-4
            text-sm text-white
            cursor-pointer
            modal-close
          "
        >
          <svg
            class="text-white fill-current"
            xmlns="http://www.w3.org/2000/svg"
            width="18"
            height="18"
            viewBox="0 0 18 18"
          >
            <path
              d="M14.53 4.53l-1.06-1.06L9 7.94 4.53 3.47 3.47 4.53 7.94 9l-4.47 4.47 1.06 1.06L9 10.06l4.47 4.47 1.06-1.06L10.06 9z"
            />
          </svg>
          <span class="text-sm">(Esc)</span>
        </div>

        <!-- Add margin if you want to see some of the overlay behind the modal-->
        <div class="px-6 py-4 text-left modal-content">
          <!--Title-->
          <div class="flex items-center justify-between pb-3">
            <p class="text-2xl font-bold" style="color:slateblue;">Ürünü Düzenle</p>

            <div class="z-50 cursor-pointer modal-close" @click="open = false">
              <svg
                class="text-black fill-current"
                xmlns="http://www.w3.org/2000/svg"
                width="18"
                height="18"
                viewBox="0 0 18 18"
              >
                <path
                  d="M14.53 4.53l-1.06-1.06L9 7.94 4.53 3.47 3.47 4.53 7.94 9l-4.47 4.47 1.06 1.06L9 10.06l4.47 4.47 1.06-1.06L10.06 9z"
                />
              </svg>
            </div>
          </div>

          <!--Body-->
          <h1
            class="
              text-gray-800
              font-lg font-italic
              tracking-normal
              leading-tight
              mb-4
            "
          >
            Ürünün değiştirmek istediğiniz özelliklerini güncelleyiniz.
          </h1>
          <label
            for="name"
            class="
              text-gray-800 text-sm
              font-bold
              leading-tight
              tracking-normal
            "
            >Ürün Adı : </label
          >
          <input id="name" class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" placeholder="Ürün adını giriniz." />
          <label
            for="name"
            class="
              text-gray-800 text-sm
              font-bold
              leading-tight
              tracking-normal
            "
            >Ürün Görseli :</label
          >
          <input id="name" class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" placeholder="Ürün görselini giriniz." />
<label
            for="name"
            class="
              text-gray-800 text-sm
              font-bold
              leading-tight
              tracking-normal
            "
            >İndirimsiz Fiyat :</label
          >
          <input id="name" class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" placeholder="Ürünün indirimsiz fiyatını giriniz." />
<label
            for="name"
            class="
              text-gray-800 text-sm
              font-bold
              leading-tight
              tracking-normal
            "
            >İndirimli Fiyat :</label
          >
          <input id="name" class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" placeholder="Ürünün indirimli fiyatını giriniz." />
<label
            for="name"
            class="
              text-gray-800 text-sm
              font-bold
              leading-tight
              tracking-normal
            "
            >Stok Sayısı :</label
          >
          <input id="name" class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" placeholder="Ürünün stok sayısını giriniz." />
<label
            for="name"
            class="
              text-gray-800 text-sm
              font-bold
              leading-tight
              tracking-normal
            "
            >Youtube URL :</label
          >
          <input id="name" class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" placeholder="Ürünün Youtube URL adresini giriniz." />
<label
            for="name"
            class="
              text-gray-800 text-sm
              font-bold
              leading-tight
              tracking-normal
            "
            >Ürün Açıklaması :</label
          >
          <input id="name" class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" placeholder="Ürünün açıklamasını giriniz." />

          

          <!--Footer-->
          <div class="flex justify-end pt-2">
            <button
              @click="open = false"
              class="
                p-3
                px-6
                py-3
                mr-2
                text-indigo-500
                bg-transparent
                rounded-lg
                hover:bg-gray-100 hover:text-indigo-400
                focus:outline-none
              "
            >
              Vazgeç
            </button>
            <button
              @click="open = false"
              class="
                px-6
                py-3
                font-medium
                tracking-wide
                text-white
                bg-indigo-600
                rounded-md
                hover:bg-indigo-500
                focus:outline-none
              "
            >
              Güncelle
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
// import Breadcrumb from '../partials/Breadcrumb.vue'

const open = ref(false);
</script>

<style>
.modal {
  transition: opacity 0.25s ease;
}
</style>
