<template>
  <div
    v-show="!result"
    class="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded relative"
    role="alert"
  >
    <strong class="font-bold">Eyvah!</strong>
    <span class="block sm:inline">Mail ya da Şifre Yanlış Girildi</span>
  </div>

  <div class="flex items-center justify-center h-screen px-6 bg-gray-200">
    <div class="w-full max-w-sm p-6 bg-white rounded-md shadow-md">
      <div class="flex items-center justify-center">
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
        <span class="text-2xl font-semibold text-gray-700">KOZMOS</span>
      </div>

      <form class="mt-4" @submit.prevent="login(email, password)">
        <label class="block">
          <span class="text-sm text-gray-700">E-mail : </span>
          <input
            type="email"
            class="block w-full mt-1 border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
            v-model="email"
          />
        </label>

        <label class="block mt-3">
          <span class="text-sm text-gray-700">Parola : </span>
          <input
            type="password"
            class="block w-full mt-1 border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
            v-model="password"
          />
        </label>

        <div class="flex items-center justify-between mt-4">
          <div>
            <label class="inline-flex items-center">
              <input
                type="checkbox"
                class="text-indigo-600 border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
              />
              <span class="mx-2 text-sm text-gray-600">Beni Hatırla</span>
            </label>
          </div>

          <div>
            <a
              class="block text-sm text-indigo-700 fontme hover:underline"
              href="#"
              >Şifreni mi unuttun ?</a
            >
          </div>
        </div>

        <div class="mt-6">
          <button
            type="submit"
            class="w-full px-4 py-2 text-sm text-center text-white bg-indigo-600 rounded-md focus:outline-none hover:bg-indigo-500"
          >
            Giriş Yap
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { useRouter } from "vue-router";
import axios from "axios";

const router = useRouter();
const email = ref("admin@example.com");
const password = ref("Admin.123");
let result = ref(true);

async function login(email: string, password: string) {
  try {
    const response = await axios.post(
      "http://kozmosapi-001-site1.itempurl.com/api/User/login",
      {
        email,
        password,
      }
    );
    if (response.data.tokenInfo.token) {
      localStorage.setItem("admin", JSON.stringify(response.data.tokenInfo));
    }

    router.push("/dashboard");
    console.log(response.data.tokenInfo.token);
  } catch (error) {
    router.push("/");
    result.value = false;
  }

  // console.log(response.data.tokenInfo.token);

  // console.log(email)
  // console.log(password)
  // if(email === "admin@example.com" && password === "Admin.123"){
  //   result.value = true;
  //   router.push("/dashboard");
  // }else{
  // router.push("/")
  // result.value = false;
  // }
}
</script>
