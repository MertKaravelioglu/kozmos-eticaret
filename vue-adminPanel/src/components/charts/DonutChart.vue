<template >
  <div >
    <apexchart
      width="650"
      type="donut"
      :options="options"
      :series="series"
    ></apexchart>
  </div>
</template>

<script lang="ts" setup>
import { ref} from "vue";
const options = ref({
  labels: ['Plak', 'Tablo', 'Giyim', 'Fotoğraf Makinesi', 'Pikap'],
  
  title: {
          text: 'Kategorilere Göre Ürün Dağılımı',
          align: 'center',
          margin: 100,
          style: {
            fontSize: '20px',
            fontFamily: 'Verdana'
          },
        },
  responsive: [{
          breakpoint: 480,
          options: {
            chart: {
              width: 1000
            },
            legend: {
              position: 'top'
            }
          }
        }]
        
});
const series = ref([44, 55, 41, 17, 15]);
</script> 







