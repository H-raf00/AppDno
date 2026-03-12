export async function load({ fetch }) {
  try {
    const response = await fetch('http://localhost:5143/api/project/all');
    const projects = await response.json();
    return { projects };
  } catch (error) {
    console.error('Error fetching projects:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { projects: [], error: errorMessage };
  }
}
