export async function load({ fetch }) {
  try {
    const response = await fetch('http://localhost:5143/api/view/all');
    const views = await response.json();
    return { views };
  } catch (error) {
    console.error('Error fetching views:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { views: [], error: errorMessage };
  }
}
