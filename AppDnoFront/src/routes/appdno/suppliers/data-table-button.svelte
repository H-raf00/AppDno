<script lang="ts">
    import { goto } from "$app/navigation";
    import { DataTableButton } from "$lib/components/ui/data-table-button/index.js";

    interface Props {
        supplierId: number;
    }

    let { supplierId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/suppliers/${supplierId}`);
    };
</script>

<DataTableButton onClick={handleNavigate} />
