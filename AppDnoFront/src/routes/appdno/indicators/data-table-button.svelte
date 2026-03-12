<script lang="ts">
    import { goto } from "$app/navigation";
    import { DataTableButton } from "$lib/components/ui/data-table-button/index.js";

    interface Props {
        indicatorId: number;
    }

    let { indicatorId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/indicators/${indicatorId}`);
    };
</script>

<DataTableButton onClick={handleNavigate} />
