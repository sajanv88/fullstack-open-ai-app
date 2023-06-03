<script lang="ts">
	import { getContext } from 'svelte';

	export let form;

	import Apps from '../components/Apps.svelte';
	import { goto } from '$app/navigation';
	import { page } from '$app/stores';
	import type {
		AppType,
		IAPIResponseOfImageCreator,
		IAPIResponseOfTextEditor,
		IFormData,
		IFormImageCreatorData
	} from '../types';
	import type { Writable } from 'svelte/store';
	import Error from '../components/Error.svelte';

	let selectedApplication: AppType;

	$: selectedApplication = ($page.url.searchParams.get('app') as AppType) ?? 'text_editor';
	const onSelectEvent = (event: Event) => {
		const target = event.target as HTMLSelectElement;
		selectedApplication = target.value as AppType;

		$page.url.searchParams.set('app', selectedApplication as string);
		goto(`?${$page.url.searchParams.toString()}`);
	};

	if (form?.app === 'text_editor') {
		const textEditorForm = getContext<Writable<IFormData>>('textEditorForm');
		const apiResponseOfTextEditor =
			getContext<Writable<IAPIResponseOfTextEditor>>('apiResponseOfTextEditor');

		textEditorForm.update((value) => {
			value = form?.formValue as IFormData;
			return value;
		});

		apiResponseOfTextEditor.update((value) => {
			value = form?.apiResponse as IAPIResponseOfTextEditor;
			return value;
		});
	} else if (form?.app === 'image_creator') {
		const imageCreatorForm = getContext<Writable<IFormImageCreatorData>>('imageCreatorForm');
		const apiResponseOfImageCreator = getContext<Writable<IAPIResponseOfImageCreator>>(
			'apiResponseOfImageCreator'
		);
		imageCreatorForm.update((value) => {
			value = form?.formValue as IFormImageCreatorData;
			return value;
		});
		apiResponseOfImageCreator.update((value) => {
			value = form?.apiResponse as IAPIResponseOfImageCreator;
			return value;
		});
	}
</script>

<section class="home-page">
	<div class="home-page__body">
		<h1 class="home-page__title" aria-label="Open Ai with Svelte">
			Open AI with Svelte & Dotnet WebApi
		</h1>
		<div class="home-page__options">
			<select class="home-page__applications" on:change={onSelectEvent} value={selectedApplication}>
				<option value="" aria-label="Choose AI Application">Choose AI Application</option>
				<option value="text_editor" aria-label="Text Editor">Text Editor</option>
				<option value="image_creator" aria-label="Image Creator">Image Creator</option>
			</select>
		</div>
		{#if form?.success === false}
			<Error message={form.errorMessage} />
		{/if}
		<Apps selectedApp={selectedApplication} />
	</div>
</section>

<style lang="scss">
	.home-page {
		display: grid;
		height: 100vh;

		justify-content: center;
		padding: 1rem;

		&__body {
			max-width: 118rem;
			margin: 0 auto;
		}
		&__title {
			font-size: 3.4rem;
			text-align: center;
		}

		&__options {
			display: flex;
			justify-content: center;
		}

		&__applications {
			background: none;
			padding: 1rem 2rem;
			color: var(--text-color);
			border: none;
		}
	}
</style>
