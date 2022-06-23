 <template>
  <div>
    <apexchart
      width="650"
      type="line"
      :options="options"
      :series="series"
    ></apexchart>
  </div>
</template>

<script lang="ts" setup>
import { ref } from "vue";
const options = ref({
  chart: {
    id: "vuechart-example",
  },
  xaxis: {
    categories: ["Ekim", "Kasım", "Aralık", "Ocak", "Şubat", "Mart", "Nisan", "Mayıs"],
  },
  title: {
          text: 'Aylara Göre Toplam Satış',
          align: 'center',
          margin: 100,
          style: {
            fontSize: '20px',
            fontFamily: 'Verdana'
          },
        },
});
const series = ref([
  {
    type: "line",
    name: "Toplam Satis",
    data: [30, 40, 45, 50, 49, 60, 70, 91],
  },
]);
</script>