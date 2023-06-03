<script lang="ts">
	import { browser } from '$app/environment';
	import { getContext } from 'svelte';
	import Image from './Image.svelte';
	import SubmitBtn from './SubmitBtn.svelte';
	import type { Writable } from 'svelte/store';
	import type { IAPIResponseOfImageCreator, IFormImageCreatorData } from '../types';
	let numberOfImageError: string;
	$: numberOfImageError = '';
	const formValue = getContext<Writable<IFormImageCreatorData>>('imageCreatorForm');
	const apiResponseOfImageCreator = getContext<Writable<IAPIResponseOfImageCreator>>(
		'apiResponseOfImageCreator'
	);
	let isProcessing: boolean;
	$: isProcessing = false;
	const onSubmitHandler = () => {
		isProcessing = true;
	};
	$: formValue;
	$: apiResponseOfImageCreator;

	$: images = $apiResponseOfImageCreator?.data ?? [];
	const onNumberOfImageEvent = (event: Event) => {
		const target = event.target as HTMLInputElement;
		const value = parseInt(target.value, 0);
		if (value < 1 || value > 10) {
			numberOfImageError = 'The number of images to generate. Must be between 1 and 10';
		}
	};
	formValue.subscribe((value) => {
		if (value?.processed) {
			isProcessing = false;
		}
	});
</script>

<section class="image-creator">
	{#if browser}
		<div class="image-creator__gallery-list">
			<div class="image-creator__gallery">
				{#each images as image}
					<Image imageSrc={image.url} imageAltName="Created using OpenAI API" />
				{/each}
			</div>
		</div>
	{/if}
	<form method="POST" action="?/createImage&app=image_creator" on:submit={onSubmitHandler}>
		<textarea
			name="prompt"
			class="image-creator__prompt"
			maxlength={1000}
			value={$formValue?.prompt ?? ''}
			placeholder="Describe the desired image(s). The maximum length is 1000 characters."
		/>
		<span class="image-creator__number-of-images--title"
			>Select number of images to be generated.</span
		>
		<input
			type="number"
			min="1"
			max="10"
			name="n"
			class="image-creator__number-of-images"
			value={$formValue?.n ?? 1}
			on:change={onNumberOfImageEvent}
		/>
		{#if numberOfImageError !== ''}
			<span class="image-creator__number-of-images--error">{numberOfImageError}</span>
		{/if}
		<div class="image-creator__sizes">
			<fieldset>
				<legend>Select image size</legend>
				<div>
					<input
						type="radio"
						name="size"
						id="sm"
						value="256x256"
						checked={$formValue?.size === '256x256'}
					/>
					<label for="sm">256x256</label>
				</div>
				<div>
					<input
						type="radio"
						name="size"
						id="md"
						value="512x512"
						checked={$formValue?.size === '512x512'}
					/>
					<label for="md">512x512</label>
				</div>
				<div>
					<input
						type="radio"
						name="size"
						id="lg"
						value="1024x1024"
						checked={$formValue?.size === '1024x1024'}
					/>
					<label for="lg">1024x1024</label>
				</div>
			</fieldset>
		</div>
		<SubmitBtn status={isProcessing} />
	</form>
</section>

<style lang="scss">
	.image-creator {
		padding-bottom: 2rem;
		&__prompt {
			display: flex;
			flex-direction: column;
			padding: 2rem 1rem;
			width: 100%;
			max-width: 98%;
			height: 10vh;
		}
		&__number-of-images {
			margin-top: 1rem;
			width: 100%;
			max-width: 98%;
			padding: 1.6rem 1rem;
			&--title {
				display: inline-flex;
				margin-top: 1rem;
				font-size: 1.8rem;
			}
			&--error {
				color: var(--error);
			}
		}

		&__sizes {
			margin-top: 1.2rem;

			fieldset {
				padding: 1rem;
				display: flex;
				align-items: center;
				legend {
					font-size: 1.8rem;
				}

				div {
					margin: 1.2rem;

					label {
						font-size: 1.6rem;
					}
				}
			}
		}

		&__gallery-list {
			margin-top: 2rem;
			margin-bottom: 2rem;
		}

		&__gallery {
			display: grid;
			justify-content: center;
			grid-gap: 2rem;
			grid-template-columns: 1fr 1fr 1fr;
		}
	}
</style>
