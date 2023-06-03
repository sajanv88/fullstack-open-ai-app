<script lang="ts">
	export let status: boolean;
</script>

<section class="submit-btn">
	<button disabled={status}>{status ? 'Processing....' : 'Submit'}</button>
</section>

<style lang="scss">
	.submit-btn {
		display: flex;
		justify-content: center;
		margin-top: 1rem;
		button {
			display: inline-flex;
			background-color: var(--primary);
			border: none;
			color: var(--text-color);
			padding: 1rem 1.2rem;

			&:hover {
				background-color: var(--primary-hover);
			}
		}
	}
</style>
