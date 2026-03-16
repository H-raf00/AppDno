<script lang="ts">
    import PersInfoTable from "./pers-info-table.svelte";
    import CustomDataTable from "$lib/components/ui/custom-data-table/custom-data-table.svelte";
    import { columns } from "./projects-columns.ts";
    export let data;

    const fields = [
        { key: "firstName", label: "Prénom" },
        { key: "lastName", label: "Nom" },
        { key: "email", label: "Addresse mail" },
        { key: "role", label: "Status" },
        { key: "group", label: "Groupe" },
    ];
</script>

<PersInfoTable user={data.user} {fields} />

<CustomDataTable {columns} data={data.user.Projets || []} />
