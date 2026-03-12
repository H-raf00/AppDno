<script lang="ts">
    import ArrowUpIcon from "@lucide/svelte/icons/arrow-up";
    import { Button } from "$lib/components/ui/button/index.js";

    interface Props {
        onClick?: () => void;
    }

    let { onClick }: Props = $props();
</script>

<div class="flex flex-col gap-8">
    <Button
        variant="outline"
        size="icon"
        class="rounded-full"
        onclick={onClick}
    >
        <ArrowUpIcon />
    </Button>
</div>
