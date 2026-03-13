<script lang="ts">
    import ArrowUpIcon from "@lucide/svelte/icons/arrow-up";
    import { Button } from "$lib/components/ui/button";

    import { goto } from "$app/navigation";

    interface Props {
        route?: string;
        onClick?: () => void;
    }

    let { route, onClick }: Props = $props();

    const handleClick = () => {
        if (route) {
            goto(route);
        } else if (onClick) {
            onClick();
        }
    };
</script>

<Button
    variant="outline"
    size="icon"
    class="rounded-full"
    onclick={handleClick}
>
    <ArrowUpIcon />
</Button>
