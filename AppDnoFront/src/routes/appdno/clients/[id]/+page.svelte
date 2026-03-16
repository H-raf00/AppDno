<script lang="ts">
    import PersInfoTable from "./pers-info-table.svelte";
    import CustomDataTable from "$lib/components/ui/custom-data-table/custom-data-table.svelte";
    import { columns } from "./projects-columns.ts";
    export let data;

    const fields = [
        { key: "name", label: "Nom" },
        { key: "codeClient", label: "Code Client" },
        { key: "projectsNumber", label: "Nombre de projets" },
    ];
</script>

<PersInfoTable client={data.client} {fields} />

<CustomDataTable {columns} data={data.client?.Projets || []} />
