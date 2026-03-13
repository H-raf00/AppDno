interface DashboardData {
  totalProjects: number;
  totalClients: number;
  totalIngredients: number;
  totalPendingIngredients: number;
}

export async function load({ fetch }) {
  try {

    const response = await fetch('http://localhost:5143/api/dashboard');
    const dashboardData: DashboardData = await response.json();
    return { dashboardData };

  } catch (error) {
    console.error('Error fetching dashboard data:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { dashboardData: undefined, error: errorMessage };
  }
}
