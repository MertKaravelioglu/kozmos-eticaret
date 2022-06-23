<template>
  <div class="flex justify-center items-center">
    <!-- Breadcrumb -->
    <!-- <Breadcrumb breadcrumb="Tables" /> -->

    <div class="mt-100 mb-100 ">
      <div class="p-3 bg-white shadow rounded-lg max-w-xl mt-10">
      <h4 class="text-black-500 font-bold">Site Info Card</h4></div>

      <div class=" max-w-xl mt-10 overflow-hidden justife-center bg-white rounded shadow-lg ">
        
        <div class="px-7 py-4">
          <div class="mb-2 text-xl font-bold text-gray-900">
            {{siteInfo.siteName}}
          </div>
          <p class="text-base text-gray-700">
            {{siteInfo.description}}
          </p>
        </div>
        <div class="px-6 pt-4 pb-2">
          <span
            class="inline-block px-3 py-1 mb-2 mr-2 text-sm font-semibold text-black-700 bg-blue-500 rounded-full"
            >#photography</span
          >
          <span
            class="inline-block px-3 py-1 mb-2 mr-2 text-sm font-semibold text-black-700 bg-blue-500 rounded-full"
            >#travel</span
          >
          <span
            class="inline-block px-3 py-1 mb-2 mr-2 text-sm font-semibold text-black-700 bg-blue-500 rounded-full"
            >#winter</span
          >
        </div>
      </div>
    </div>

   

    
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import axios from "axios";



//import Breadcrumb from '../partials/Breadcrumb.vue'
const siteInfo = ref({
  phoneNumber: "",
  description: "",
  keyWords: "",
  facebookUrl: "",
  instagramUrl: "",
  linkedinUrl: "",
  siteName: "",
});
onMounted(async () => {
  await axios
    .get("http://kozmosapi-001-site1.itempurl.com/api/SiteInfo")
    .then((response) => {
      console.log(response.data)
      siteInfo.value = response.data;
    });
  
});  
</script>