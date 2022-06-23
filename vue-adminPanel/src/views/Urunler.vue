<template>
  <div>
    <div class="mt-8"></div>

    <div class="flex flex-col mt-8">
      <div class="py-2 -my-2 overflow-x-auto sm:-mx-6 sm:px-6 lg:-mx-8 lg:px-8">
        <div
          class="inline-block min-w-full overflow-hidden align-middle border-b border-gray-200 shadow sm:rounded-lg"
        >
          <table class="min-w-full">
            <thead>
              <tr>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  ID
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Urun Adi
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Urun Gorseli
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Indirimsiz Fiyat
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Indirimli Fiyat
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Stok Sayisi
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Youtube URL
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Urun Aciklamasi
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  DÜZENLE - SİL
                </th>
                <th
                  class="px-6 py-3 text-xs font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50"
                >
                  Resim Ekle
                </th>
              </tr>
            </thead>

            <tbody class="bg-white">
              <tr v-for="product in products" :key="product.productId">
                <!-- <tr v-for="(u, index) in users" :key="index"> -->

                <td
                  class="px-6 py-4 border-b border-gray-200 whitespace-nowrap"
                >
                  <div class="text-sm leading-5 text-gray-900">
                    {{ product.productId }}
                  </div>
                </td>

                <td
                  class="px-6 py-4 border-b border-gray-200 whitespace-nowrap"
                >
                  <div class="text-sm leading-5 text-gray-900">
                    {{ product.productName }}
                  </div>
                  <div
                    class="inline-flex px-5 text-xs font-semibold leading-5 text-green-800 bg-sky-200 rounded-full"
                  >
                    {{ product.categoryName }}
                  </div>
                </td>

                <td
                  class="px-6 py-4 border-b border-gray-200 whitespace-nowrap"
                >
                  <span
                    class="inline-flex px-2 text-xs font-semibold leading-5 text-green-800 rounded-full"
                  >
                    <span v-if="product.productImage.length > 1">
                      Görsel Ekli
                    </span>
                    <span v-else> Görsel Ekli Değil </span>
                  </span>
                </td>

                <td
                  class="px-8 py-4 text-sm leading-5 text-red-700 border-b border-gray-200 whitespace-nowrap"
                >
                  {{ product.priceWithoutDiscount }}
                </td>
                <td
                  class="px-8 py-4 text-sm leading-5 text-green-700 border-b border-gray-200 whitespace-nowrap"
                >
                  {{ product.priceWithDiscount }}
                </td>
                <td
                  class="px-6 py-4 text-sm leading-5 text-gray-500 border-b border-gray-200 whitespace-nowrap"
                >
                  {{ product.stock }}
                </td>
                <td
                  class="px-6 py-4 text-sm leading-5 text-gray-500 border-b border-gray-200 whitespace-nowrap"
                >
                  <a
                    class="inline-flex items-center h-8 px-4 m-2 text-sm text-indigo-100 transition-colors duration-150 bg-indigo-700 rounded-lg focus:shadow-outline hover:bg-indigo-800"
                    :href="product.youtubeUrl"
                    >Link</a
                  >
                </td>
                <td
                  class="px-6 py-4 text-sm leading-5 text-gray-500 border-b border-gray-200 whitespace-nowrap"
                >
                  {{ product.productDescription }}
                </td>
                <td
                  class="px-6 py-4 text-sm font-medium leading-5 text-right border-b border-gray-200 whitespace-nowrap"
                >
                  <div class="flex justify-around">
                    <span class="text-yellow-500 flex justify-center">
                      <td>
                        <button
                          @click="open = true"
                          class="px-3 py-2 mt-3 font-medium tracking-wide text-white bg-indigo-200 rounded-md hover:bg-indigo-500 focus:outline-none"
                        >
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            height="24"
                            width="24"
                          >
                            <path
                              d="M2.1 23.875V22.025H21.9V23.875ZM5.025 19.1V16.85L13.775 8.15L16 10.375L7.325 19.1ZM5.95 18.175H6.875L14.7 10.375L13.775 9.45L5.95 17.275ZM16.85 9.4 14.625 7.25 15.725 6.15Q15.975 5.875 16.375 5.875Q16.775 5.875 17.075 6.15L17.875 6.975Q18.15 7.25 18.175 7.65Q18.2 8.05 17.925 8.325ZM5.95 18.175Z"
                            />
                          </svg>
                        </button>
                      </td>

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
                          class="z-50 w-11/12 mx-auto overflow-y-auto bg-white rounded shadow-lg modal-container md:max-w-md"
                        >
                          <div
                            class="absolute top-0 right-0 z-50 flex flex-col items-center mt-4 mr-4 text-sm text-white cursor-pointer modal-close"
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

                          <div class="px-6 py-4 text-left modal-content">
                            <!--Title-->
                            <div class="flex items-center justify-between pb-3">
                              <p
                                class="text-2xl font-bold"
                                style="color: slateblue"
                              >
                                Ürünü Düzenle
                              </p>

                              <div
                                class="z-50 cursor-pointer modal-close"
                                @click="open = false"
                              >
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
                              class="text-gray-800 font-lg font-italic tracking-normal leading-tight mb-4"
                            >
                              Ürünün değiştirmek istediğiniz özelliklerini
                              güncelleyiniz.
                            </h1>
                            <label
                              for="name"
                              class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
                              >Ürün Adı :
                            </label>
                            <input
                              id="name"
                              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                              placeholder="Ürün adını giriniz."
                            />

                            <label
                              for="name"
                              class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
                              >Ürün Görseli :</label
                            >
                            <input
                              id="name"
                              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                              placeholder="Ürün görselini giriniz."
                            />
                            <label
                              for="name"
                              class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
                              >İndirimsiz Fiyat :</label
                            >
                            <input
                              id="name"
                              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                              placeholder="Ürünün indirimsiz fiyatını giriniz."
                            />
                            <label
                              for="name"
                              class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
                              >İndirimli Fiyat :</label
                            >
                            <input
                              id="name"
                              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                              placeholder="Ürünün indirimli fiyatını giriniz."
                            />
                            <label
                              for="name"
                              class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
                              >Stok Sayısı :</label
                            >
                            <input
                              id="name"
                              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                              placeholder="Ürünün stok sayısını giriniz."
                            />
                            <label
                              for="name"
                              class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
                              >Youtube URL :</label
                            >
                            <input
                              id="name"
                              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                              placeholder="Ürünün Youtube URL adresini giriniz."
                            />
                            <label
                              for="name"
                              class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
                              >Ürün Açıklaması :</label
                            >
                            <input
                              id="name"
                              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                              placeholder="Ürünün açıklamasını giriniz."
                            />

                            <!--Footer-->
                            <div class="flex justify-end pt-2">
                              <button
                                @click="open = false"
                                class="p-3 px-6 py-3 mr-2 text-indigo-500 bg-transparent rounded-lg hover:bg-gray-100 hover:text-indigo-400 focus:outline-none"
                              >
                                Vazgeç
                              </button>
                              <button
                                @click="open = false"
                                class="px-6 py-3 font-medium tracking-wide text-white bg-indigo-600 rounded-md hover:bg-indigo-500 focus:outline-none"
                              >
                                Güncelle
                              </button>
                            </div>
                          </div>
                        </div>
                      </div>
                      <td>
                        <button
                          @click="deleteItem(product.productId)"
                          class="px-3 py-2 mt-3 font-medium tracking-wide text-white bg-red-400 rounded-md hover:bg-red-600 focus:outline-none"
                        >
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            height="24"
                            width="24"
                          >
                            <path
                              d="M7.65 19.85Q7.025 19.85 6.575 19.4Q6.125 18.95 6.125 18.3V6.05H5.15V5.125H9.025V4.375H14.975V5.125H18.875V6.05H17.9V18.3Q17.9 18.95 17.45 19.4Q17 19.85 16.35 19.85ZM16.975 6.05H7.05V18.3Q7.05 18.55 7.238 18.738Q7.425 18.925 7.65 18.925H16.35Q16.575 18.925 16.775 18.738Q16.975 18.55 16.975 18.3ZM9.875 16.95H10.8V8.025H9.875ZM13.2 16.95H14.125V8.025H13.2ZM7.05 6.05V18.3Q7.05 18.575 7.05 18.75Q7.05 18.925 7.05 18.925Q7.05 18.925 7.05 18.75Q7.05 18.575 7.05 18.3Z"
                            />
                          </svg>
                        </button>
                      </td>
                    </span>
                  </div>
                </td>
                <td>
                  <form
                    method="post"
                    @submit.prevent="onUpload(product.productId)"
                  >
                    <label class="block">
                      <input
                        type="file"
                        class="block w-full text-sm text-gray-500 file:py-2 file:px-6 file:rounded file:border-1 file:border-gray-400"
                        @change="addImage"
                      />

                      <button
                        type="submit"
                        class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
                      >
                        Yükle
                      </button>
                    </label>
                  </form>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
    <button
      @click="open = true"
      class="flex items-center justify-center py-2 px-3 mt-4 font-medium tracking-wide text-white bg-indigo-600 rounded-md hover:bg-indigo-500 focus:outline-none"
    >
      <svg
        class="w-9 h-8 mr-4 fill-white flex items-center justify-center"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          d="M18.958 31.208V21.042H8.75V18.917H18.958V8.708H21.083V18.917H31.25V21.042H21.083V31.208Z"
        />
      </svg>
      Ürün Ekle
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
        class="z-50 w-11/12 mx-auto overflow-y-auto bg-white rounded shadow-lg modal-container md:max-w-md"
      >
        <div
          class="absolute top-0 right-0 z-50 flex flex-col items-center mt-4 mr-4 text-sm text-white cursor-pointer modal-close"
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
            <p class="text-2xl font-bold" style="color: slateblue">
              Yeni Ürün Ekle
            </p>

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
            class="text-gray-800 font-lg font-italic tracking-normal leading-tight mb-4"
          >
            Ürünün eklemek istediğiniz özelliklerini giriniz.
          </h1>
          <label
            for="name"
            class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
            >Ürün Adı :
          </label>
          <input
            id="name"
            class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
            placeholder="Ürün adını giriniz."
          />
          <label
            for="name"
            class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
            >Ürün Görseli :</label
          >
          <input
            id="name"
            class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
            placeholder="Ürün görselini giriniz."
          />
          <label
            for="name"
            class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
            >İndirimsiz Fiyat :</label
          >
          <input
            id="name"
            class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
            placeholder="Ürünün indirimsiz fiyatını giriniz."
          />
          <label
            for="name"
            class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
            >İndirimli Fiyat :</label
          >
          <input
            id="name"
            class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
            placeholder="Ürünün indirimli fiyatını giriniz."
          />
          <label
            for="name"
            class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
            >Stok Sayısı :</label
          >
          <input
            id="name"
            class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
            placeholder="Ürünün stok sayısını giriniz."
          />
          <label
            for="name"
            class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
            >Youtube URL :</label
          >
          <input
            id="name"
            class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
            placeholder="Ürünün Youtube URL adresini giriniz."
          />
          <label
            for="name"
            class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
            >Ürün Açıklaması :</label
          >
          <input
            id="name"
            class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
            placeholder="Ürünün açıklamasını giriniz."
          />

          <!--Footer-->
          <div class="flex justify-end pt-2">
            <button
              @click="open = false"
              class="p-3 px-6 py-3 mr-2 text-indigo-500 bg-transparent rounded-lg hover:bg-gray-100 hover:text-indigo-400 focus:outline-none"
            >
              Vazgeç
            </button>
            <button
              @click="open = false"
              class="px-6 py-3 font-medium tracking-wide text-white bg-indigo-600 rounded-md hover:bg-indigo-500 focus:outline-none"
            >
              Ekle
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup lang="ts">
import { ref, onMounted } from "vue";
import axios from "axios";
import { autheader } from "../helpers/auth-helper";
const open = ref(false);
//import Breadcrumb from "../partials/Breadcrumb.vue";
interface User {
  name: string;
  email: string;
  title: string;
  title2: string;
  status: string;
  role: string;
}

const testUser: User = {
  name: "Ecem Doe",
  email: "john@example.com",
  title: "Software Engineer",
  title2: "Web dev",
  status: "Active",
  role: "Owner",
};
const products = ref([]);
let selectedFile: any = null;
onMounted(async () => {
  await axios
    .get("http://kozmosapi-001-site1.itempurl.com/api/Products")
    .then((response) => {
      products.value = response.data;
    });
  console.log(products);
});
const deleteItem = async (productId: number) => {
  await axios
    .delete(
      `http://kozmosapi-001-site1.itempurl.com/api/Products/${productId}`,
      {
        headers: {
          Authorization: "Bearer " + autheader(),
        },
      }
    )
    .then((response) => {
      console.log(response);
      window.location.reload();
    });
};

const addImage = (e: any) => {
  selectedFile = e.target.files[0];
  console.log("selectedFile");
  console.log(selectedFile);
};

const onUpload = async (id: string) => {
  const fd = new FormData();

  fd.append("file", selectedFile, selectedFile.name);

  try {
    await axios.post(
      `http://kozmosapi-001-site1.itempurl.com/api/Products/addImage/${id}`,
      fd,
      {
        headers: {
          Authorization: "Bearer " + autheader(),
        },
      }
    );
    window.location.reload();
  } catch (error) {
    console.log(error);
  }
};

const users = ref<User[]>([...Array(10).keys()].map(() => testUser));
</script>
<style>
.modal {
  transition: opacity 0.25s ease;
}
</style>
