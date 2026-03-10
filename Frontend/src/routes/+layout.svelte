<script>
	let { children } = $props();
</script>

<nav>
	<a href="/">Home</a>
	<a href="/login">Login</a>
</nav>

{@render children()}
