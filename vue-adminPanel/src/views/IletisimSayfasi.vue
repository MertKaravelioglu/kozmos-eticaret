<template>
  <div>
    <!-- Breadcrumb -->
    <!-- <Breadcrumb breadcrumb="Tables" /> -->

    <div class="mt-4">
      <h4 class="text-black-600">KULLANICI MESAJLARI</h4>

      <div class="mt-6">
        <div class="my-6 overflow-hidden bg-white rounded-md shadow">
          <table class="w-full text-left border-collapse">
            <thead class="border-b">
              <tr>
                <th
                  class="px-5 py-3 text-sm font-medium text-gray-100 uppercase bg-indigo-800"
                >
                  Tam İsim
                </th>
                <th
                  class="px-5 py-3 text-sm font-medium text-gray-100 uppercase bg-indigo-800"
                >
                  E-mail
                </th>
                <th
                  class="px-5 py-3 text-sm font-medium text-gray-100 uppercase bg-indigo-800"
                >
                  Mesaj Başlığı
                </th>
                <th
                  class="px-5 py-3 text-sm font-medium text-gray-100 uppercase bg-indigo-800"
                >
                  Mesaj İçeriği
                </th>
                <th
                  class="px-5 py-3 text-sm font-medium text-gray-100 uppercase bg-indigo-800"
                >
                  Çözülme Durumu
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="message in messages"
                :key="message.title"
                class="hover:bg-gray-200"
              >
                <td class="px-6 py-4 text-lg text-gray-700 border-b">
                  {{ message.applicationUserFullName }}
                </td>
                <td class="px-6 py-4 text-lg text-gray-700 border-b">
                  {{ message.applicationUserEmail }}
                </td>
                <td class="px-6 py-4 text-lg text-gray-700 border-b">
                  {{ message.title }}
                </td>
                <td class="px-6 py-4 text-gray-500 border-b">
                  {{ message.text }}
                </td>
                <td class="px-6 py-4 text-gray-500 border-b">
                  {{ message.isResolved }}
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import axios from "axios";
import { useTableData } from "../hooks/useTableData";
import { autheader } from "../helpers/auth-helper";
const { simpleTableData, paginatedTableData, wideTableData } = useTableData();

//import Breadcrumb from '../partials/Breadcrumb.vue'
const messages = ref([]);
onMounted(async () => {
  await axios
    .get("http://kozmosapi-001-site1.itempurl.com/api/CustomerMessage", {
      headers: {
        Authorization: "Bearer " + autheader(),
      },
    })
    .then((response) => {
      messages.value = response.data;
    });
  console.log(messages);
});
</script>
