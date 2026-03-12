<script>
  export let data;
</script>

<h1>Clients</h1>

{#if data.error}
  <p class="text-red-500">Erreur lors du chargement des clients : {data.error}</p>
{:else if data.clients.length === 0}
  <p>Aucun client trouvé.</p>
{:else}
  <div class="grid grids-cols-auto gap-4 mt-8">
    {#each data.clients as client, i (i)}
      <div class="border border-gray-300 rounded-lg p-4 bg-gray-50">
        <p><strong>Nom:</strong> {client.lastName}</p>
        <p><strong>Rôle:</strong> {client.role}</p>
        <p><strong>Groupe:</strong> {client.group}</p>
        <p><strong>Nombre de projets:</strong> {client.projectNumber}</p>
      </div>
    {/each}
  </div>
{/if}
