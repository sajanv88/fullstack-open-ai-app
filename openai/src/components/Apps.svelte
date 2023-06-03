<script lang="ts">
	import type { AppType } from '../types';
	import ImageCreator from './ImageCreator.svelte';
	import TextEditor from './TextEditor.svelte';

	export let selectedApp: AppType;
</script>

<section class="apps">
	{#if selectedApp === 'text_editor'}
		<TextEditor />
	{:else if selectedApp === 'image_creator'}
		<ImageCreator />
	{/if}
</section>

<style lang="scss">
	.apps {
		margin-top: 2rem;
		padding-top: 1rem;
		border-top: 1px solid var(--text-color);
	}
</style>
