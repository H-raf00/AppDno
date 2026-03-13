export async function load({ fetch }) {
  try {
    const response = await fetch('http://localhost:5143/api/user/all');
    const users = await response.json();
    return { users };
  } catch (error) {
    console.error('Error fetching users:', error);
    const errorMessage = error instanceof Error ? error.message : 'Unknown error';
    return { users: [], error: errorMessage };
  }
}
