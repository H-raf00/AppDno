<script lang="ts">
  export let client;
  export let fields: { key: string; label: string }[] = [];
</script>

<div class="max-w-xl mx-auto mt-8 bg-white rounded-lg shadow p-6">
  <table class="w-full text-left border-separate border-spacing-y-2">
    <tbody>
      {#each fields as field, i}
        <tr>
          <td class="font-medium text-gray-600 py-2">{field.label}</td>
          <td class="py-2 text-gray-900">{client?.[field.key] || 'N/A'}</td>
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