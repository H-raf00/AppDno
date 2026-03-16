<script lang="ts">
import { PersInfoTable } from "$lib/components/ui/pers-info-table";
import { CustomDataTable } from "$lib/components/ui/custom-data-table";
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

<div class = "mb-4">
<PersInfoTable object={clientData} fields={fields} route="/appdno/clients"/>
</div>
<div class = "mb-4">
<CustomDataTable {columns} data={projetsData} />
</div>