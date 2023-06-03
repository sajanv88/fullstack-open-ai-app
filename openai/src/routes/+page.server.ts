import type { IFormData, IFormImageCreatorData } from '../types';
import type { Actions } from './$types';
import { IMAGE_CREATOR_ENDPOINT, TEXT_EDITOR_ENDPOINT } from '$env/static/private';

const callApi = async (endpoint: string, payload: Record<string, string>, app: string) => {
	const response = await fetch(endpoint, {
		headers: { 'content-type': 'application/json' },
		method: 'post',
		body: JSON.stringify(payload)
	});
	if (!response.ok || response.status !== 200) {
		const errorMessage = await response.json();
		return {
			success: false,
			app,
			errorMessage: errorMessage?.error?.message ?? 'Api error! For more details check api logs'
		};
	}
	const apiResponse = await response.json();
	return {
		success: true,
		app,
		apiResponse
	};
};

export const actions = {
	editText: async ({ request }) => {
		const formData = await request.formData();
		const input = formData.get('input') as string;
		const instruction = formData.get('instruction') as string;
		const payload: Record<string, string> = {
			input,
			instruction,
			model: 'text-davinci-edit-001'
		};
		const response = await callApi(TEXT_EDITOR_ENDPOINT, payload, 'text_editor');
		return {
			...response,
			formValue: {
				input: input as string,
				instruction: instruction as string,
				processed: true
			} satisfies IFormData
		};
	},
	createImage: async ({ request }) => {
		const formData = await request.formData();
		const prompt = formData.get('prompt') as string;
		const n = formData.get('n') ?? 1;
		const size = (formData.get('size') as string) ?? '256x256';
		const payload: Record<string, string | any> = {
			prompt,
			n,
			size
		};
		const response = await callApi(IMAGE_CREATOR_ENDPOINT, payload, 'image_creator');
		return {
			...response,
			formValue: {
				prompt: prompt as string,
				n: n as number,
				size: size as string,
				processed: true
			} satisfies IFormImageCreatorData
		};
	}
} satisfies Actions;
