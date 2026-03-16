export async function load({ fetch, params }) {
  try {
    const response = await fetch(`http://localhost:5143/api/client/${params.id}`);
    const client = await response.json();
    return { client };
  } catch (error) {
    console.error('Error fetching the client:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { client: null, error: errorMessage };
  }
}
