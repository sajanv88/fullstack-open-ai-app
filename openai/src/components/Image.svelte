<script lang="ts">
	export let imageSrc: string;
	export let imageAltName: string;
	let loading: boolean;
	$: loading = true;
	const onLoaded = () => {
		loading = false;
	};
</script>

<figure class="image">
	{#if loading}
		<div class="image__loading">
			<span>Loading...</span>
		</div>
	{/if}
	<img src={imageSrc} alt={imageAltName} class:hidden={loading} on:load|self={onLoaded} />
</figure>

<style lang="scss">
	.image {
		width: 100%;
		margin: 0;
		&__loading {
			width: 30rem;
			height: 10rem;
			display: flex;
			justify-content: center;
			font-size: 1.8rem;
			align-items: center;
		}
		img {
			width: 100%;
			height: auto;
		}
		.hidden {
			display: none;
		}
	}
</style>
