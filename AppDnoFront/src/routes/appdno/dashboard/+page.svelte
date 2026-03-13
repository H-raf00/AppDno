<script lang="ts">
  import { DashboardCard } from "$lib/components/ui/dashboard-card";
  let { data } = $props();
</script>

<div class="grid grid-cols-4 gap-4">
  <DashboardCard label="Nombre de Projets" value={data.dashboardData?.totalProjects ?? 0} />
  <DashboardCard label="Nombre de Clients" value={data.dashboardData?.totalClients ?? 0} />
  <DashboardCard label="Nombre des Ingrédients" value={data.dashboardData?.totalIngredients ?? 0} />
  <DashboardCard label="Nombre des Ingrédients en attente" value={data.dashboardData?.totalPendingIngredients ?? 0} />
</div>
