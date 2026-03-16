<script lang="ts">
  import ArrowNavButton from "$lib/components/ui/arrow-nav-button/arrow-nav-button.svelte";
  
  interface Props {
    object: any;
    fields?: { key: string; label: string }[];
    showButton?: boolean;
    arrowDirection?: "up" | "down" | "left" | "right";
    route?: string;
  }

  let { object, fields = [], showButton = true, arrowDirection = "left", route = "#" }: Props = $props();
</script>

<div class="w-full bg-white rounded-lg shadow p-6 relative">
  {#if showButton}
    <div class="absolute top-6 right-6">
      <ArrowNavButton direction={arrowDirection} route={route} />
    </div>
  {/if}
  <table class="w-full text-left border-separate border-spacing-y-2">
    <tbody>
      {#each fields as field, i}
        <tr>
          <td class="font-medium text-gray-600 py-2">{field.label}</td>
          <td class="py-2 text-gray-900">{object?.[field.key] || 'N/A'}</td>
        </tr>
        {#if i < fields.length - 1}
          <tr>
            <td colspan="2" class="border-b border-gray-200"></td>
          </tr>
        {/if}
      {/each}
    </tbody>
  </table>
</div>