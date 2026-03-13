<script lang="ts">
 import { CustomDataTable } from "$lib/components/ui/custom-data-table";
 import { columns } from "./columns.js";
 
 let { data } = $props();
</script>
 
<CustomDataTable data={data.suppliers} {columns} />
