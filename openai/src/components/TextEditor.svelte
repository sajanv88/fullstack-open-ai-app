<script lang="ts">
	import { getContext } from 'svelte';
	import type { Writable } from 'svelte/store';
	import type { IAPIResponseOfTextEditor, IFormData } from '../types';
	import SubmitBtn from './SubmitBtn.svelte';
	let isProcessing: boolean;
	$: isProcessing = false;
	const onSubmitHandler = () => {
		isProcessing = true;
	};
	const formValue = getContext<Writable<IFormData>>('textEditorForm');
	const apiResponseOfTextEditor =
		getContext<Writable<IAPIResponseOfTextEditor>>('apiResponseOfTextEditor');

	$: formValue;
	$: apiResponseOfTextEditor;

	formValue.subscribe((value) => {
		if (value?.processed) {
			isProcessing = false;
		}
	});
</script>

<section class="text-editor">
	<h2
		class="text-editor__title"
		title="Given a prompt and an instruction, the model will display an edited version of the prompt in the
		output field."
	>
		Given a prompt and an instruction, the model will display an edited version of the prompt in the
		output field.
	</h2>

	<form class="text-editor__form" method="POST" action="?/editText" on:submit={onSubmitHandler}>
		<section class="text-editor__body">
			<section class="text-editor__input">
				<textarea
					name="input"
					value={$formValue?.input ?? ''}
					class="text-editor__text-area"
					placeholder="Past your text content"
					aria-label="Past your text content"
				/>
				<input
					type="text"
					value={$formValue?.instruction ?? ''}
					name="instruction"
					class="text-editor__instruction-field"
					aria-label="Enter the instruction"
					placeholder="Provide an instruction"
				/>
			</section>

			<section class="text-editor__output">
				<textarea
					disabled
					value={$apiResponseOfTextEditor?.choices.map((c) => c.text).join('\n') ?? ''}
					class="text-editor__text-area"
					aria-label="Edited version will be shown here."
					placeholder="Edited version will be shown here."
				/>
			</section>
		</section>
		<SubmitBtn status={isProcessing} />
	</form>
</section>

<style lang="scss">
	.text-editor {
		&__title {
			font-size: 1.4rem;
			text-align: center;
			padding: 1rem;
		}
		&__body {
			display: grid;
			grid-template-columns: auto auto;
			grid-gap: 1rem;
		}

		&__input {
			display: flex;
			flex-direction: column;
		}
		&__text-area {
			border: none;
			resize: none;
			padding: 1rem;
			width: 40rem;
			height: 40rem;

			&:disabled {
				background-color: var(--bg-text-editor-output);
			}
		}
		&__instruction-field {
			padding: 1rem;
			margin-top: 1rem;
		}
	}
</style>
