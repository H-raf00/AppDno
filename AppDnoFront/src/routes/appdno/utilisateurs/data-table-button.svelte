<script lang="ts">
    import { goto } from "$app/navigation";
    import ArrowUpIcon from "@lucide/svelte/icons/arrow-up";
    import { Button } from "$lib/components/ui/button/index.js";

    interface Props {
        userId: number;
    }

    let { userId }: Props = $props();

    const handleNavigate = () => {
        goto(`/appdno/show_user?id=${userId}`);
    };
</script>

<div class="flex flex-col gap-8">
    <Button
        variant="outline"
        size="icon"
        class="rounded-full"
        onclick={handleNavigate}
    >
        <ArrowUpIcon />
    </Button>
</div>
