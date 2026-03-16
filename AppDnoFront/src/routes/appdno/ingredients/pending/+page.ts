export async function load({ fetch }) {
  try {
    const status = "pending";
    const response = await fetch(`http://localhost:5143/api/ingredient/all?status=${encodeURIComponent(status)}`);
    const pendingIngredients = await response.json();
    return { pendingIngredients: pendingIngredients };
  } catch (error) {
    console.error('Error fetching pending ingredients:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { pendingIngredients: [], error: errorMessage };
  }
}
