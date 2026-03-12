<script lang="ts">
    import { goto } from "$app/navigation";
    import { DataTableButton } from "$lib/components/ui/data-table-button/index.js";

    interface Props {
        viewId: number;
    }

    let { viewId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/views/${viewId}`);
    };
</script>

<DataTableButton onClick={handleNavigate} />
