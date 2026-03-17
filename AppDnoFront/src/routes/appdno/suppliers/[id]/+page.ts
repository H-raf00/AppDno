export async function load({ fetch, params }) {
  try {
    const response = await fetch(`http://localhost:5143/api/supplier/${params.id}`);
    const supplier = await response.json();
    return { supplier };
  } catch (error) {
    console.error('Error fetching the supplier:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { supplier: null, error: errorMessage };
  }
}
