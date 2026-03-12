<script lang="ts">
    import { goto } from "$app/navigation";
    import { DataTableButton } from "$lib/components/ui/data-table-button/index.js";

    interface Props {
        userId: number;
    }

    let { userId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/user/${userId}`);
    };
</script>

<DataTableButton onClick={handleNavigate} />
