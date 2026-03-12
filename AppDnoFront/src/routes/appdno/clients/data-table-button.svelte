<script lang="ts">
    import { goto } from "$app/navigation";
    import { DataTableButton } from "$lib/components/ui/data-table-button/index.js";

    interface Props {
        clientId: number;
    }

    let { clientId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/clients/${clientId}`);
    };
</script>

<DataTableButton onClick={handleNavigate} />
