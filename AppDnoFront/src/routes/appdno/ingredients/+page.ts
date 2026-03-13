export async function load() {
  try {
    const response = await fetch('http://localhost:5143/api/ingredient/all');
    const ingredients = await response.json();
    return { ingredients };
  } catch (error) {
    console.error('Error fetching ingredients:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { ingredients: [], error: errorMessage };
  }
}
