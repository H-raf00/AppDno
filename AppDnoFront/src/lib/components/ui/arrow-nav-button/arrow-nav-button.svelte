<script lang="ts">
    import ArrowUpIcon from "@lucide/svelte/icons/arrow-up";
    import ArrowDownIcon from "@lucide/svelte/icons/arrow-down";
    import ArrowLeftIcon from "@lucide/svelte/icons/arrow-left";
    import ArrowRightIcon from "@lucide/svelte/icons/arrow-right";
    import { Button } from "$lib/components/ui/button";

    import { goto } from "$app/navigation";

    interface Props {
        route?: string;
        onClick?: () => void;
        direction?: "up" | "down" | "left" | "right";
    }

    let { route, onClick, direction = "up" }: Props = $props();

    const iconMap = {
        up: ArrowUpIcon,
        down: ArrowDownIcon,
        left: ArrowLeftIcon,
        right: ArrowRightIcon,
    };

    const IconComponent = $derived(iconMap[direction]);

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
    <IconComponent />
</Button>
