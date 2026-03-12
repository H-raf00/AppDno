<script lang="ts">
    import { goto } from "$app/navigation";
    import { DataTableButton } from "$lib/components/ui/data-table-button/index.js";

    interface Props {
        ingredientId: number;
    }

    let { ingredientId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/ingredients/${ingredientId}`);
    };
</script>

<DataTableButton onClick={handleNavigate} />
