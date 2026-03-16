export async function load({ fetch, params }) {
  try {
    const response = await fetch(`http://localhost:5143/api/user/${params.id}`);
    const user = await response.json();
    return { user };
  } catch (error) {
    console.error('Error fetching the user:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { user: null, error: errorMessage };
  }
}
