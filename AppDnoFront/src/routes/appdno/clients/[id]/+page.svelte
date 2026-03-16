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

const clientData = data.client || {};
const projetsData = clientData.Projets || [];
</script>

<PersInfoTable client={clientData} {fields} />

<CustomDataTable {columns} data={projetsData} />
