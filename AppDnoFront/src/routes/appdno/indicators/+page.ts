export async function load() {
  try {
    const response = await fetch('http://localhost:5143/api/indicator/all');
    const indicators = await response.json();
    return { indicators };
  } catch (error) {
    console.error('Error fetching indicators:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { indicators: [], error: errorMessage };
  }
}
