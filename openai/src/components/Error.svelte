<script lang="ts">
	export let message = "Oh no, it didn't work as expected. Try again please.";
</script>

<section class="error">
	<article class="error__article">
		<p>{message}</p>
	</article>
</section>

<style lang="scss">
	.error {
		display: grid;
		margin-top: 1rem;
		background-color: var(--error);
		padding: 0.6rem;
		&__article {
			display: flex;
			padding: 0 1.8rem;
			align-items: baseline;
			font-size: 1.8rem;
			p {
				flex: 1;
			}
		}
	}
</style>
