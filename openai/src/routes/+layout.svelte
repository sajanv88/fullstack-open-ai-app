<script lang="ts">
	import { setContext } from 'svelte';
	import { writable } from 'svelte/store';
	import type {
		IAPIResponseOfTextEditor,
		IFormData,
		IFormImageCreatorData,
		IAPIResponseOfImageCreator
	} from '../types';

	// text editor app context
	const textEditorForm = writable<IFormData>();
	const apiResponseOfTextEditor = writable<IAPIResponseOfTextEditor>();
	textEditorForm.set({ input: '', instruction: '' });
	setContext('textEditorForm', textEditorForm);
	setContext('apiResponseOfTextEditor', apiResponseOfTextEditor);

	// image creator app context
	const imageCreatorForm = writable<IFormImageCreatorData>();
	const apiResponseOfImageCreator = writable<IAPIResponseOfImageCreator>();
	setContext('imageCreatorForm', imageCreatorForm);
	setContext('apiResponseOfImageCreator', apiResponseOfImageCreator);
</script>

<slot />

<style lang="scss">
	:global(html) {
		--background-color: #1e293b;
		--text-color: #f8fafc;
		--font-size: 62.5%;
		--white: #fff;
		--primary: #0ea5e9;
		--primary-hover: #38bdf8;
		--error: #f43f5e;
		--bg-text-editor-output: #fef9c3;
		font-size: var(--font-size);
	}
	:global(body) {
		background-color: var(--background-color);
		color: var(--text-color);
		margin: 0;
		padding: 0;

		*,
		*::after,
		*::before {
			box-sizing: border-box;
		}
	}
</style>
