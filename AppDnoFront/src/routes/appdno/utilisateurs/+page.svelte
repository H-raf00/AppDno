<script lang="ts">
 import DataTable from "./data-table.svelte";
 import { columns } from "./columns.js";
 
 let { data } = $props();
</script>
 
<DataTable data={data.users} {columns} />

<!--
{#if data.error}
  <p class="text-red-500">Erreur lors du chargement des utilisateurs : {data.error}</p>
{:else if data.users.length === 0}
  <p>Aucun utilisateur trouvé.</p>
{:else}
  <div class="grid grids-cols-auto gap-4 mt-8">
    {#each data.users as user, i (i)}
      <div class="border border-gray-300 rounded-lg p-4 bg-gray-50">
        <p><strong>Nom:</strong> {user.lastName}</p>
        <p><strong>Rôle:</strong> {user.role}</p>
        <p><strong>Groupe:</strong> {user.group}</p>
        <p><strong>Nombre de projets:</strong> {user.projectNumber}</p>
      </div>
    {/each}
  </div>
{/if}-->