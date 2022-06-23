<template>
  <div>
    <!-- Breadcrumb -->
    <!-- <Breadcrumb breadcrumb="charts" /> -->

    <div class="mt-4">
      <h4 class="text-gray-600" style="font-size:40px;">GRAFIKLER</h4>

      <div class="mt-6">
        <div
          class="
            my-6
            overflow-hidden
            bg-white
            rounded-md
            shadow
            grid grid-cols-2
            gap-3
          "
        >
          <LineChart />
          <!-- <br> -->
          <DonutChart />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
// import Breadcrumb from "../partials/Breadcrumb.vue";
import DonutChart from "@/components/charts/DonutChart.vue";
import LineChart from "@/components/charts/LineChart.vue";
//import { ref, onMounted } from "vue";

import axios from "axios";

// const products = ref([]);
// onMounted(async () => {
//   await axios
//     .get("http://kozmosapi-001-site1.itempurl.com/api/Products")
//     .then((response) => {
//       products.value = response.data;
//     });
//   console.log(products);
// });

</script>
