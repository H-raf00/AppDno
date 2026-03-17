<script lang="ts">
    import PersInfoTable from "$lib/components/ui/pers-info-table/pers-info-table.svelte";
    import CustomDataTable from "$lib/components/ui/custom-data-table/custom-data-table.svelte";
    import { columns } from "./projects-columns.ts";
    export let data;

    const fields = [
        { key: "name", label: "Nom" },
    ];

    const supplierData = data.supplier || {};
    const ingredientsData = supplierData.ingredients || [];
</script>

<div class="mb-4">
    <PersInfoTable object={supplierData} {fields} route="/appdno/suppliers" />
</div>
<div class="mb-4">
    <CustomDataTable {columns} data={ingredientsData} />
</div>
