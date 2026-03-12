<script lang="ts">
    import { goto } from "$app/navigation";
    import { DataTableButton } from "$lib/components/ui/data-table-button/index.js";

    interface Props {
        projectId: number;
    }

    let { projectId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/projects/${projectId}`);
    };
</script>

<DataTableButton onClick={handleNavigate} />
