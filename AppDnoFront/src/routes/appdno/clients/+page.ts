export async function load({ fetch }) {
  try {
    const response = await fetch('http://localhost:5143/api/client/all');
    const clients = await response.json();
    return { clients };
  } catch (error) {
    console.error('Error fetching clients:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { clients: [], error: errorMessage };
  }
}
