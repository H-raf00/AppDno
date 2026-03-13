export async function load({ fetch }) {
  try {
    const response = await fetch('http://localhost:5143/api/supplier/all');
    const suppliers = await response.json();
    return { suppliers };
  } catch (error) {
    console.error('Error fetching suppliers:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { suppliers: [], error: errorMessage };
  }
}
