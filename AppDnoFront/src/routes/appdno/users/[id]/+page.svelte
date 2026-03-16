<script lang="ts">
    import PersInfoTable from "$lib/components/ui/pers-info-table/pers-info-table.svelte";
    import CustomDataTable from "$lib/components/ui/custom-data-table/custom-data-table.svelte";
    import { columns } from "./projects-columns.ts";
    export let data;

    const fields = [
        { key: "firstName", label: "Prénom" },
        { key: "lastName", label: "Nom" },
        { key: "email", label: "Addresse mail" },
        { key: "role", label: "Rôle" },
        { key: "group", label: "Groupe" },
    ];

    const userData = data.user || {};
    const projectsData = userData.projects || [];
</script>

<div class="mb-4">
    <PersInfoTable object={userData} {fields} route="/appdno/users" />
</div>
<div class="mb-4">
    <CustomDataTable {columns} data={projectsData} />
</div>
